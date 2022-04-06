fetch("https://localhost:7248/api/categories").then(res => res.json()).then(data => {
    for(let category of data) {
        document.getElementById('category').innerHTML += `<option value="${category.id}">${category.name}</option>`
    }
})

function handleSubmit(e) {
    e.preventDefault()

    let json = JSON.stringify({
        name: e.target['name'].value,
        price: Number(e.target['price'].value),
        categoryId: Number(e.target['category'].value)
    })

    fetch("https://localhost:7248/api/products", {
        'method': 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: json
    })
    .then(res => res.json())
    .then(data => {
        console.log(data)
    })
}