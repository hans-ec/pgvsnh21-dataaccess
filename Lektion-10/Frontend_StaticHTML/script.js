function getProducts() {
    fetch('https://localhost:7094/api/Products')
    .then(res => res.json())
    .then(data => {
        console.log(data)
        
        for(let p of data) {
            document.getElementById('productlist').innerHTML += 
            `
            <div class="mb-5">
                <p><strong>${p.name} (${p.articleNumber})</strong></p>
                <p class="text-muted mb-1"><small>${p.categoryName}</small></p>
                <p>${p.price} :-</p>
                <button onclick="removeProduct('${p.articleNumber}')" class="btn btn-danger">Ta bort</button>
            </div>     
            `
        }
    })
}

function removeProduct(artnr) {
    fetch('https://localhost:7094/api/Products/' + artnr, {
        method: 'delete'
    } )
    .then(res => {
        location.reload();   
    })
}

function handleSubmit(event) {
    event.preventDefault()

    data = {
        articleNumber: event.target['articleNumber'].value,
        name: event.target['name'].value,
        price: Number(event.target['price'].value),
        categoryName: event.target['categoryName'].value
    }

    fetch('https://localhost:7094/api/Products', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
    .then(res => {
        if (res.status === 200)
            window.location.replace("index.html");
    })
}