addEventListener('load', () => {
    getOrderProducts()
    let sum=0
    let items = JSON.parse(sessionStorage.getItem("orderItems"))
    document.getElementById("itemCount").textContent = items.length
    for (let i = 0; i < items.length; i++) {
         sum+=items[i].price
    }
    document.getElementById("totalAmount").textContent = sum
})
const getOrderProducts =async() => {
    products =JSON.parse(sessionStorage.getItem("orderItems"))
    for (let i = 0; i < products.length; i++) {
        drawItem(products[i])
    }
}    
const drawItem = async(product)=> { 
let tmp = document.getElementById("temp-row");
    let cloneProduct = tmp.content.cloneNode(true)
    let url = `../Image/${product.imgUrl}` 
    cloneProduct.querySelector(".image").style.backgroundImage = `url(${url})`
    cloneProduct.querySelector(".itemName").textContent = product.productName
    cloneProduct.querySelector(".price").innerText = product.price   
    cloneProduct.getElementById("delete").addEventListener('click', () => {
        click(product)     
    })
    document.getElementById("items").appendChild(cloneProduct)
}   
   
const click = (product) => {
    console.log(product.productId)
    products = JSON.parse(sessionStorage.getItem("orderItems"))
    console.log(products)
    let j = 0
    //use indexOf instead of for loop
    for ( j = 0; j < products.length; j++) {

        if (products[j].productId == product.productId) {
            
            break;
        }
    }
    products.splice(j, 1)
    sessionStorage.setItem("orderItems", JSON.stringify(products))
    window.location.href = "ShoppingBag.html"
    //document.getElementById("items").innerHTML = ""
    getOrderProducts()
}

const setOrderItem = async () => {

    const order = GetDataFromDocumentForRegister();
    try {

        const response = await fetch("api/Order", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newUser)//?
        });
        console.log(response)
        if (!response.ok) {
            console.log(`HTTP error! status:${newUser.status}`)//?
            alert("שם משתמש או סיסמה אינם תקינים")//?
        }
        else
            alert("New user!")//?
    } catch (error) {
        console.log(error)
    }
}


placeOrder =async () => {
    let user = JSON.parse(sessionStorage.getItem("id")) || null;
    if (user == null) {
        window.location.href = "Login.html"
    }
    let shoppingBag = JSON.parse(sessionStorage.getItem("orderItems")) || [];
    let products = []
    let sum=0
    for (let i = 0; i < shoppingBag.length; i++) {
        let thisProduct = { ProductId: shoppingBag[i].productId, Quentity: 1 }
        console.log(shoppingBag[i].productId)
        sum += shoppingBag[i].price
        products.push(thisProduct)
    }
    try {

        const orderPost = await fetch("../api/Order", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                OrderDate: "2025-01-05",
                OrderSum: sum,
                UserId: user,
                OrderItems: products
            })

        });
        if (orderPost.status == 204)
              alert("Not found product")
        if (!orderPost.ok) 
          throw new Error(`HTTP error! status:${orderPost.status}`)
        const data = await orderPost.json()
        console.log(data)
        alert(`order number ${data.orderId} seccied!`)
        sessionStorage.setItem("orderItems", JSON.stringify([]))
        window.location.href="Products.html"
       
    }
    catch (error) {
        alert("try again"+eror)
        console.log(error)
    }
}






