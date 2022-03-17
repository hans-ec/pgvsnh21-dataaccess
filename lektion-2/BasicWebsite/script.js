function onSubmit(e) {
    e.preventDefault()

    let json = JSON.stringify({ categoryName : e.target['categoryName'].value })

    fetch('https://localhost:7018/api/Categories', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: json
    })

    e.target['categoryName'].value = ''

}