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

const removeCartItemFromCart = async (cartItem) => {
  const response = await fetch(`https://localhost:44360/api/cartItem/delete`, {
    method: "DELETE",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(cartItem),
  });
};

const createOrder = async () => {
  let order = {};
  order.userId = parseInt(localStorage.getItem("UserId"));
  order.locationId = parseInt(localStorage.getItem("UserLocationId"));
  let date = new Date();
  order.orderDate = date.toJSON();

  const response = await fetch(`https://localhost:44360/api/order/add`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(order),
  });
  return response.json();
};

const getOrder = async (orderId) => {
  const response = await fetch(
    `https://localhost:44360/api/order/get/${orderId}`
  );
  return response.json();
};

const updateOrder = async (orderTotal, orderId) => {
  let order = await getOrder(orderId);
  order.totalPrice = orderTotal;

  const response = await fetch(`https://localhost:44360/api/order/edit`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(order),
  });
  const success = response.json();
  if (success) {
    console.log("Order total updated!");
  }
};

const getInventoryItemByLocationIdBookId = async (locationId, bookId) => {
  const response = await fetch(
    `https://localhost:44360/api/inventory/get/${locationId}/${bookId}`
  );
  return response.json();
};

const adjustInventoryLevels = async (bookId, quantity) => {
  let locationId = parseInt(localStorage.getItem("UserLocationId"));
  let item = await getInventoryItemByLocationIdBookId(locationId, bookId);
  item.quantity -= quantity;
  const response = await fetch(`https://localhost:44360/api/inventory/edit`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(item),
  });
  const success = response.json();
  if (success) {
    console.log("Inventory level adjusted!");
  }
};

//TODO add final check to ensure cart items dont exceed inv levels
const checkOut = async () => {
  const cartItems = await getUserCartItems();
  const order = await createOrder();
  let orderTotal = 0;

  for (let i = 0; i < cartItems.length; i++) {
    let lineItem = {};
    lineItem.orderId = order.id;
    lineItem.bookId = cartItems[i].bookId;
    lineItem.quantity = cartItems[i].quantity;

    let book = await getBookById(cartItems[i].bookId);
    lineItem.price = book.price;

    orderTotal += parseFloat(lineItem.price);

    const response = await fetch(`https://localhost:44360/api/lineItem/add`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(lineItem),
    });
    const success = response.json();
    if (success) {
      await updateOrder(orderTotal, order.id);
      await removeCartItemFromCart(cartItems[i]);
      adjustInventoryLevels(book.id, lineItem.quantity);
      displayUserCart();
    }
  }
  alert("Your purchase has been made!");
  //TODO display a receipt
};

const getCartItemById = async (id) => {
  const response = await fetch(
    `https://localhost:44360/api/cartItem/get/id/${id}`
  );
  return response.json();
};

const removeFromCart = async () => {
  let id = document.querySelector('#cartItemId').value;
  const cartItem = await getCartItemById(id);

  const response = await fetch(`https://localhost:44360/api/cartItem/delete`, {
    method: "DELETE",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(cartItem),
  });
    displayUserCart();
}
