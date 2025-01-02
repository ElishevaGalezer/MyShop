const GetDataFromDocumentForFilter = () => {
    const minPrice = parseInt( document.querySelector("#minPrice").value);
    const maxPrice =parseInt( document.querySelector("#maxPrice").value);
    const categoryIds = document.querySelector("#categoryList").value;
    const desc = document.querySelector("#nameSearch").value;

    return ({ desc, minPrice, maxPrice, categoryIds });
}

const filterProducts = async () => {
    const obj = GetDataFromDocumentForFilter()
    let url = `../api/Products`
    if (obj.desc || obj.minPrice || obj.maxPrice || obj.categoryIds) {
        if (obj.desc)
            url += `&desc=${obj.desc}`
        if (obj.minPrice)
            url += `&minPrice=${obj.minPrice}`
        if (obj.maxPrice)
            url += `&maxPrice=${obj.maxPrice}`
        if (obj.categoryIds)
            url += `&categoryIds=${obj.categoryIds}`
    }
          try {
             
              
              const Products = await fetch(url, {
                          method: "GET",
                          headers: {
                              'Content-type': 'application/json'
                          },
                          query: {
                              desc: obj.desc,
                              minPrice: obj.minPrice,
                              maxPrice: obj.maxPrice,
                              categoryIds: obj.categoryIds
                          }
                      });
              const data = await Products.json();
                      console.log(data)
              if (!Products.ok) {
                  throw new Error(`HTTP error! status:${Products.status}`);
                      }
              else
                  drawProducts(data) 

                  } catch (error) {
                      console.log(error)
                  }
              }
const drawTemplate = async (product) => {
    let tmp = document.getElementById("temp-card");
    let cloneProduct = tmp.content.cloneNode(true)
    cloneProduct.querySelector("img").src = "../Image" + product.imgURL
    cloneProduct.querySelector("h1").textContent = product.productName
    cloneProduct.querySelector(".price").innerText = product.price
    cloneProduct.querySelector(".description").innerText = product.description
    //cloneProduct.querySelector(".button").addEventListener('click', () => { addToCart(product) })
    document.getElementById("PoductList").appendChild(cloneProduct)
}
const drawProducts = async (products) => {
    for (let i = 0; i < products.length; i++) {
        drawTemplate(products[i])
    }

    const addToCart = () => {

    }
}

   

