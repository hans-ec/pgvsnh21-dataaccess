function handleSubmit(e) {
    e.preventDefault()

    let customer = {
        customerName: e.target['customerName'].value,
        contactPerson: {
            firstName: e.target['firstName'].value,
            lastName: e.target['lastName'].value,
            email: e.target['email'].value
        }
    }

    let json = JSON.stringify(customer)

    fetch('https://localhost:7199/api/customers', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: json
    })
}