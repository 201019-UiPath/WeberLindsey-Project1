function DisplayLocationOptions() {
  fetch(`https://localhost:44360/api/location/get`)
    .then((response) => response.json())
    .then((result) => {
      document
        .querySelectorAll("#locations tbody tr")
        .forEach((element) => element.remove());
      let table = document.querySelector("#locations tbody");

      for (let i = 0; i < result.length; ++i) {
        let row = table.insertRow(table.rows.length);

        let idCell = row.insertCell(0);
        idCell.innerHTML = result[i].id;

        let streetCell = row.insertCell(1);
        streetCell.innerHTML = result[i].street1;

        let cityCell = row.insertCell(2);
        cityCell.innerHTML = result[i].city;

        let stateCell = row.insertCell(3);
        stateCell.innerHTML = result[i].state;
      }
    });
}

// Get Orders and Line Items for each order for the current user
const getOrdersByUserId = async (userId) => {
  // let locationId = document.querySelector("#locationId").value;
  const response = await fetch(
    `https://localhost:44360/api/order/get/user/${userId}`
  );
  return response.json();
};

const getLineItemsByOrderId = async (orderId) => {
  const response = await fetch(
    `https://localhost:44360/api/lineItem/get/${orderId}`
  );
  return response.json();
};

const getBookById = async (bookId) => {
  const response = await fetch(
    `https://localhost:44360/api/book/get/${bookId}`
  );
  return response.json();
};

const getLocationByLocationId = async (locationId) => {
  const response = await fetch(
    `https://localhost:44360/api/location/get/${locationId}`
  );
  return response.json();
};

//TODO these don't get orders by the selected locationId, just all existing orders
const getAllOrdersForCurrentCustomer = async () => {
  const userId = localStorage.getItem("UserId");
  const orders = await getOrdersByUserId(userId);

  document
    .querySelectorAll("#orders tbody tr")
    .forEach((element) => element.remove());
  let table = document.querySelector("#orders tbody");

  for (let i = 0; i < orders.length; i++) {
    let outerheaderrow = table.insertRow(table.rows.length);
    let lCell = outerheaderrow.insertCell(0);
    let dCell = outerheaderrow.insertCell(1);
    let toCell = outerheaderrow.insertCell(2);
    let itCell = outerheaderrow.insertCell(3);
    lCell.innerHTML = "Location";
    dCell.innerHTML = "Date";
    toCell.innerHTML = "Total";
    // itCell.innerHTML = "Items";
    
    let row = table.insertRow(table.rows.length);
    let locationCell = row.insertCell(0);
    let dateCell = row.insertCell(1);
    let totalCell = row.insertCell(2);
    let itemsCell = row.insertCell(3);
    dateCell.innerHTML = orders[i].orderDate;
    totalCell.innerHTML = orders[i].totalPrice;

    let location = await getLocationByLocationId(orders[i].locationId);
    locationCell.innerHTML = `${location.city}, ${location.state}`;

    const lineItems = await getLineItemsByOrderId(orders[i].id);
    // itemsCell.innerHTML = lineItems.length;

    let innerHeaderRow = table.insertRow(table.rows.length);
    let tCell = innerHeaderRow.insertCell(0);
    let aCell = innerHeaderRow.insertCell(1);
    let pCell = innerHeaderRow.insertCell(2);
    let qCell = innerHeaderRow.insertCell(3);
    tCell.innerHTML = "Title";
    aCell.innerHTML = "Author";
    pCell.innerHTML = "Price";
    qCell.innerHTML = "Quantity";

    for (let x = 0; x < lineItems.length; x++) {
      let book = await getBookById(lineItems[x].bookId);
      let innercontentrow = table.insertRow(table.rows.length);

      let innerRow = table.insertRow(table.rows.length);
      let titleCell = innercontentrow.insertCell(0);
      let authorCell = innercontentrow.insertCell(1);
      let priceCell = innercontentrow.insertCell(2);
      let quantityCell = innercontentrow.insertCell(3);
      titleCell.innerHTML = book.title;
      authorCell.innerHTML = book.author;
      priceCell.innerHTML = book.price;
      quantityCell.innerHTML = lineItems[x].quantity;
    }
  }
};

// Sort orders for locations by Date & Price
const getOrdersByUserIdDateAsc = async () => {
  const userId = localStorage.getItem("UserId");
  const response = await fetch(
    `https://localhost:44360/api/order/get/user/date/asc/${userId}`
  );
  return response.json();
};

const getOrdersByUserIdDateDesc = async () => {
  const userId = localStorage.getItem("UserId");
  const response = await fetch(
    `https://localhost:44360/api/order/get/user/date/desc/${userId}`
  );
  return response.json();
};

const getOrdersByUserIdPriceAsc = async () => {
  const userId = localStorage.getItem("UserId");
  const response = await fetch(
    `https://localhost:44360/api/order/get/user/price/asc/${userId}`
  );
  return response.json();
};

const getOrdersByUserIdPriceDesc = async () => {
  const userId = localStorage.getItem("UserId");
  const response = await fetch(
    `https://localhost:44360/api/order/get/user/price/desc/${userId}`
  );
  return response.json();
};

const sortOrdersByDateAsc = async () => {
  const orders = await getOrdersByUserIdDateAsc();

  document
    .querySelectorAll("#orders tbody tr")
    .forEach((element) => element.remove());
  let table = document.querySelector("#orders tbody");

  for (let i = 0; i < orders.length; i++) {
    let row = table.insertRow(table.rows.length);
    let locationCell = row.insertCell(0);
    let dateCell = row.insertCell(1);
    let totalCell = row.insertCell(2);
    let itemsCell = row.insertCell(3);
    dateCell.innerHTML = orders[i].orderDate;
    totalCell.innerHTML = orders[i].totalPrice;

    let location = await getLocationByLocationId(orders[i].locationId);
    locationCell.innerHTML = `${location.city}, ${location.state}`;

    const lineItems = await getLineItemsByOrderId(orders[i].id);
    // itemsCell.innerHTML = lineItems.length;

    for (let x = 0; x < lineItems.length; x++) {
      let book = await getBookById(lineItems[x].bookId);
      let innerHeaderRow = table.insertRow(table.rows.length);
      let tCell = innerHeaderRow.insertCell(0);
      let aCell = innerHeaderRow.insertCell(1);
      let pCell = innerHeaderRow.insertCell(2);
      let qCell = innerHeaderRow.insertCell(3);
      tCell.innerHTML = "Title";
      aCell.innerHTML = "Author";
      pCell.innerHTML = "Price";
      qCell.innerHTML = "Quantity";

      let innerRow = table.insertRow(table.rows.length);
      let titleCell = innerRow.insertCell(0);
      let authorCell = innerRow.insertCell(1);
      let priceCell = innerRow.insertCell(2);
      let quantityCell = innerRow.insertCell(3);
      titleCell.innerHTML = book.title;
      authorCell.innerHTML = book.author;
      priceCell.innerHTML = book.price;
      quantityCell.innerHTML = lineItems[x].quantity;
    }
  }
};

const sortOrdersByDateDesc = async () => {
  const orders = await getOrdersByUserIdDateDesc();

  document
    .querySelectorAll("#orders tbody tr")
    .forEach((element) => element.remove());
  let table = document.querySelector("#orders tbody");

  for (let i = 0; i < orders.length; i++) {
    let row = table.insertRow(table.rows.length);
    let locationCell = row.insertCell(0);
    let dateCell = row.insertCell(1);
    let totalCell = row.insertCell(2);
    let itemsCell = row.insertCell(3);
    dateCell.innerHTML = orders[i].orderDate;
    totalCell.innerHTML = orders[i].totalPrice;

    let location = await getLocationByLocationId(orders[i].locationId);
    locationCell.innerHTML = `${location.city}, ${location.state}`;

    const lineItems = await getLineItemsByOrderId(orders[i].id);
    // itemsCell.innerHTML = lineItems.length;

    for (let x = 0; x < lineItems.length; x++) {
      let book = await getBookById(lineItems[x].bookId);
      let innerHeaderRow = table.insertRow(table.rows.length);
      let tCell = innerHeaderRow.insertCell(0);
      let aCell = innerHeaderRow.insertCell(1);
      let pCell = innerHeaderRow.insertCell(2);
      let qCell = innerHeaderRow.insertCell(3);
      tCell.innerHTML = "Title";
      aCell.innerHTML = "Author";
      pCell.innerHTML = "Price";
      qCell.innerHTML = "Quantity";

      let innerRow = table.insertRow(table.rows.length);
      let titleCell = innerRow.insertCell(0);
      let authorCell = innerRow.insertCell(1);
      let priceCell = innerRow.insertCell(2);
      let quantityCell = innerRow.insertCell(3);
      titleCell.innerHTML = book.title;
      authorCell.innerHTML = book.author;
      priceCell.innerHTML = book.price;
      quantityCell.innerHTML = lineItems[x].quantity;
    }
  }
};

const sortOrdersByPriceAsc = async () => {
  const orders = await getOrdersByUserIdPriceAsc();

  document
    .querySelectorAll("#orders tbody tr")
    .forEach((element) => element.remove());
  let table = document.querySelector("#orders tbody");

  for (let i = 0; i < orders.length; i++) {
    let row = table.insertRow(table.rows.length);
    let locationCell = row.insertCell(0);
    let dateCell = row.insertCell(1);
    let totalCell = row.insertCell(2);
    let itemsCell = row.insertCell(3);
    dateCell.innerHTML = orders[i].orderDate;
    totalCell.innerHTML = orders[i].totalPrice;

    let location = await getLocationByLocationId(orders[i].locationId);
    locationCell.innerHTML = `${location.city}, ${location.state}`;

    const lineItems = await getLineItemsByOrderId(orders[i].id);
    // itemsCell.innerHTML = lineItems.length;

    for (let x = 0; x < lineItems.length; x++) {
      let book = await getBookById(lineItems[x].bookId);
      let innerHeaderRow = table.insertRow(table.rows.length);
      let tCell = innerHeaderRow.insertCell(0);
      let aCell = innerHeaderRow.insertCell(1);
      let pCell = innerHeaderRow.insertCell(2);
      let qCell = innerHeaderRow.insertCell(3);
      tCell.innerHTML = "Title";
      aCell.innerHTML = "Author";
      pCell.innerHTML = "Price";
      qCell.innerHTML = "Quantity";

      let innerRow = table.insertRow(table.rows.length);
      let titleCell = innerRow.insertCell(0);
      let authorCell = innerRow.insertCell(1);
      let priceCell = innerRow.insertCell(2);
      let quantityCell = innerRow.insertCell(3);
      titleCell.innerHTML = book.title;
      authorCell.innerHTML = book.author;
      priceCell.innerHTML = book.price;
      quantityCell.innerHTML = lineItems[x].quantity;
    }
  }
};

const sortOrdersByPriceDesc = async () => {
  const orders = await getOrdersByUserIdPriceDesc();

  document
    .querySelectorAll("#orders tbody tr")
    .forEach((element) => element.remove());
  let table = document.querySelector("#orders tbody");

  for (let i = 0; i < orders.length; i++) {
    let row = table.insertRow(table.rows.length);
    let locationCell = row.insertCell(0);
    let dateCell = row.insertCell(1);
    let totalCell = row.insertCell(2);
    let itemsCell = row.insertCell(3);
    dateCell.innerHTML = orders[i].orderDate;
    totalCell.innerHTML = orders[i].totalPrice;

    let location = await getLocationByLocationId(orders[i].locationId);
    locationCell.innerHTML = `${location.city}, ${location.state}`;

    const lineItems = await getLineItemsByOrderId(orders[i].id);
    // itemsCell.innerHTML = lineItems.length;

    for (let x = 0; x < lineItems.length; x++) {
      let book = await getBookById(lineItems[x].bookId);
      let innerHeaderRow = table.insertRow(table.rows.length);
      let tCell = innerHeaderRow.insertCell(0);
      let aCell = innerHeaderRow.insertCell(1);
      let pCell = innerHeaderRow.insertCell(2);
      let qCell = innerHeaderRow.insertCell(3);
      tCell.innerHTML = "Title";
      aCell.innerHTML = "Author";
      pCell.innerHTML = "Price";
      qCell.innerHTML = "Quantity";

      let innerRow = table.insertRow(table.rows.length);
      let titleCell = innerRow.insertCell(0);
      let authorCell = innerRow.insertCell(1);
      let priceCell = innerRow.insertCell(2);
      let quantityCell = innerRow.insertCell(3);
      titleCell.innerHTML = book.title;
      authorCell.innerHTML = book.author;
      priceCell.innerHTML = book.price;
      quantityCell.innerHTML = lineItems[x].quantity;
    }
  }
};
