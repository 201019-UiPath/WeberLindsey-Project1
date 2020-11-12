function GetAllBooks() {
    //TODO change this to get all books for customer's location
    
    fetch('https://localhost:44360/api/book/get')
    .then(response => response.json())
    .then(result => {
        document.querySelectorAll('#books tbody tr').forEach(element => element.remove());
        let table = document.querySelector('#books tbody');

        for(let i = 0; i < result.length; i++) {
            let row = table.insertRow(table.rows.length);

            let titleCell = row.insertCell(0);
            titleCell.innerHTML = result[i].title;

            let authorCell = row.insertCell(1);
            authorCell.innerHTML = result[i].author;

            let priceCell = row.insertCell(2);
            priceCell.innerHTML = result[i].price;

            let quantityCell = row.insertCell(3);
            //hideCell.innerHTML = result[i].price;

            let synopsisCell = row.insertCell(4);
            synopsisCell.innerHTML = result[i].synopsis;

            let addCell = row.insertCell(5);
            let btn = document.createElement('input');
            btn.type = 'button';
            btn.id = result[i].id;
            btn.value = 'Add to Cart';

            btn.onclick = function AddToCart() {
                //TODO add way of entering in quantity or incrementing quantity
                let cartItem = {}
                cartItem.cartId = 51; //Temp value
                cartItem.bookId = btn.id;
                cartItem.quantity = 1; //Temp value

                let xhr = new XMLHttpRequest();

                xhr.onreadystatechange = function() {
                    if(this.readyState == 4 && this.status > 199 && this.status < 300) {
                        alert('Added to Cart!')
                    }
                };

                xhr.open("POST", 'https://localhost:44360/api/cartItem/add', true);
                xhr.setRequestHeader('Content-type', 'application/json');
                xhr.send(JSON.stringify(cartItem));
            };

            addCell.appendChild(btn);
        }
    });
}