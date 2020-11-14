const getUserCart = async () => {
  let userId = localStorage.getItem("UserId");
  const response = await fetch(
    `https://localhost:44360/api/cart/get/${userId}`
  );
  return response.json();
};

const getUserCartItems = async () => {
  const cart = await getUserCart();
  const response = await fetch(
    `https://localhost:44360/api/cartItem/get/${cart.id}`
  );
  return response.json();
};

const getBookById = async (bookId) => {
  const response = await fetch(
    `https://localhost:44360/api/book/get/${bookId}`
  );
  return response.json();
};

const displayUserCart = async () => {
  const cartItems = await getUserCartItems();

  document
    .querySelectorAll("#cart tbody tr")
    .forEach((element) => element.remove());
  let table = document.querySelector("#cart tbody");

  for (let i = 0; i < cartItems.length; i++) {
    let row = table.insertRow(table.rows.length);
    let idCell = row.insertCell(0);
    idCell.innerHTML = cartItems[i].id;

    let book = await getBookById(cartItems[i].bookId);
    let titleCell = row.insertCell(1);
    let authorCell = row.insertCell(2);
    let priceCell = row.insertCell(3);
    let quantityCell = row.insertCell(4);

    titleCell.innerHTML = book.title;
    authorCell.innerHTML = book.author;
    priceCell.innerHTML = book.price;
    quantityCell.innerHTML = cartItems[i].quantity;
  }
};

const createOrder = async () => {
  let order = {};
  order.userId = parseInt(localStorage.getItem("UserId"));
  order.locationId = parseInt(localStorage.getItem("UserLocationId"));
  order.orderDate = 0;

  console.log(order);

  const response = await fetch(`https://localhost:44360/api/order/add`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(order),
  });
  return response.json();
};

const checkOut = async () => {
  const cartItems = await getUserCartItems();
  const order = await createOrder();
  let orderTotal = 0;

  for (let i = 0; i < cartItems.length; i++) {
    let orderItem = {};
    orderItem.orderId = order.id;
    orderItem.bookId = cartItems[i].bookId;
    orderItem.price = cartItems[i].price;
    orderItem.quantity = cartItems[i].quantity;
    
    orderTotal += cartItems[i].price;

    const response = await fetch(`https://localhost:44360/api/orderItem/add`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(orderItem),
    });
    const success = response.json();
    if (success) {
      alert("Your purchase has been made!");
      //TODO add function to update the order total
    }
  }
};

//   const response = await fetch(`https://localhost:44360/api/order/add`, {
//     method: "POST",
//     headers: { "Content-Type": "application/json" },
//     body: JSON.stringify(order),
//   });
//   const success = response.json();
//   if (success) {
//     for (let i = 0; i < cartItems.length; i++) {
//       let orderItem = {};
//       orderItem.orderId = success.id;
//       orderItem.bookId = cartItems[i].bookId;
//       orderItem.price = cartItems[i].price;
//       orderItem.quantity = cartItems[i].quantity;

//       const response = await fetch(
//         `https://localhost:44360/api/orderItem/add`,
//         {
//           method: "POST",
//           headers: { "Content-Type": "application/json" },
//           body: JSON.stringify(orderItem),
//         }
//       );
//       const success = response.json();
//       if (success) {
//         alert("Your purchase has been made!");
//       }
//     }
//   }
// };
