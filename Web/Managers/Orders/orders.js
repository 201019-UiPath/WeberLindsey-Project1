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

// Get Orders and Line Items for each order for the selected location
const getOrdersByLocationId = async () => {
  let locationId = document.querySelector("#locationId").value;
  const response = await fetch(
    `https://localhost:44360/api/order/get/location/${locationId}`
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

const getAllOrdersAtLocation = async () => {
  const orders = await getOrdersByLocationId();

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

// Sort orders for locations by Date & Price
const getOrdersByLocationIdDateAsc = async () => {
  let locationId = document.querySelector("#locationId").value;
  const response = await fetch(
    `https://localhost:44360/api/order/get/location/date/asc/${locationId}`
  );
  return response.json();
};

const getOrdersByLocationIdDateDesc = async () => {
  let locationId = document.querySelector("#locationId").value;
  const response = await fetch(
    `https://localhost:44360/api/order/get/location/date/desc/${locationId}`
  );
  return response.json();
};

const getOrdersByLocationIdPriceAsc = async () => {
  let locationId = document.querySelector("#locationId").value;
  const response = await fetch(
    `https://localhost:44360/api/order/get/location/price/asc/${locationId}`
  );
  return response.json();
};

const getOrdersByLocationIdPriceDesc = async () => {
  let locationId = document.querySelector("#locationId").value;
  const response = await fetch(
    `https://localhost:44360/api/order/get/location/price/desc/${locationId}`
  );
  return response.json();
};

const sortOrdersByDateAsc = async () => {
  const orders = await getOrdersByLocationIdDateAsc();

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
  const orders = await getOrdersByLocationIdDateDesc();

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
  const orders = await getOrdersByLocationIdPriceAsc();

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
  const orders = await getOrdersByLocationIdPriceDesc();

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
