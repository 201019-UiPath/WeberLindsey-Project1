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

// Get inventory items for selected location
const getInventoryByLocationId = async () => {
  let locationId = document.querySelector("#locationId").value;
  const response = await fetch(
    `https://localhost:44360/api/inventory/get/${locationId}`
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

async function getAllBooksAtLocation() {
  const inventory = await getInventoryByLocationId();
  document
    .querySelectorAll("#books tbody tr")
    .forEach((element) => element.remove());
  let table = document.querySelector("#books tbody");

  for (let i = 0; i < inventory.length; i++) {
    let row = table.insertRow(table.rows.length);
    let idCell = row.insertCell(0);
    let titleCell = row.insertCell(1);
    let authorCell = row.insertCell(2);
    let priceCell = row.insertCell(3);
    let locationCell = row.insertCell(4);
    let quantityCell = row.insertCell(5);
    quantityCell.innerHTML = inventory[i].quantity;

    let book = await getBookById(inventory[i].bookId);
    idCell.innerHTML = book.id;
    titleCell.innerHTML = book.title;
    authorCell.innerHTML = book.author;
    priceCell.innerHTML = book.price;

    let location = await getLocationByLocationId(inventory[i].locationId);
    locationCell.innerHTML = `${location.city}, ${location.state}`;
  }
}

//TODO will need to adjust this to get all books not at locations as well or have just the products displayed with their location Id in the table?

//Functions to create new book and add it to location inventory
const getBookFromHTML = () => ({
  title: document.querySelector("#title").value,
  author: document.querySelector("#author").value,
  price: parseFloat(document.querySelector("#price").value),
  synopsis: document.querySelector("#synopsis").value,
});

const getInventoryItemFromHTML = () => ({
  quantity: parseInt(document.querySelector("#quantity").value, 10),
  locationId: parseInt(document.querySelector("#locationId").value, 10),
});

const getBookByTitle = async (title) => {
  const response = await fetch(
    `https://localhost:44360/api/book/get/title/${title}`
  );
  return response.json();
};

//TODO check if book already exists before creating it
const createNewBook = async () => {
  const book = getBookFromHTML();

  const response = await fetch(`https://localhost:44360/api/book/add`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(book),
  });
  return response.json();
};

const clearForm = () => {
  document.querySelector("#title").value = "";
  document.querySelector("#author").value = "";
  document.querySelector("#price").value = "";
  document.querySelector("#synopsis").value = "";
  document.querySelector("#quantity").value = "";
  document.querySelector("#locationId").value = "";
};

const createNewInventoryItem = async () => {
  const { id } = await createNewBook();
  const item = { ...getInventoryItemFromHTML(), bookId: id };

  const response = await fetch(`https://localhost:44360/api/inventory/add`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(item),
  });
  const success = response.json();
  if (success) {
    alert("New Item Added!");
    clearForm();
  }
};

const getInventoryItemByLocationIdBookId = async (locationId, bookId) => {
  const response = await fetch(
    `https://localhost:44360/api/inventory/get/${locationId}/${bookId}`
  );
  return response.json();
};

const replenishBook = async () => {
  let bookId = document.querySelector("#editBookId").value;
  let locationId = document.querySelector("#locationId").value;

  const item = await getInventoryItemByLocationIdBookId(locationId, bookId);
  item.quantity = item.quantity + parseInt(document.querySelector("#editBookQuantity").value);

  const response = await fetch(`https://localhost:44360/api/inventory/edit`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(item),
  });
  const success = response.json();
  if (success) {
    alert("Item replenished!");
    getAllBooksAtLocation();
    document.querySelector("#editBookId").value = "";
    document.querySelector("#editBookQuantity").value = "";
  }
};

const removeBook = async () => {
  let bookId = document.querySelector("#removeBook").value;
  let locationId = document.querySelector("#locationId").value;

  const item = getInventoryItemByLocationIdBookId(locationId, bookId);

  const response = await fetch(`https://localhost:44360/api/inventory/delete`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(item),
  });
  const success = response.json();
  if (success) {
    alert("Item Removed from inventory!");
    clearForm();
  }
};
