const getLocationByLocationId = async (locationId) => {
  const response = await fetch(
    `https://localhost:44360/api/location/get/${locationId}`
  );
  return response.json();
};

const userLocation = async () => {
  let locationId = localStorage.getItem("UserLocationId");
  let location = await getLocationByLocationId(locationId);
  let locDisplay = document.createTextNode(
    `Your current preferred location : ${location.city}, ${location.state}`
  );
  document.querySelector("#location").appendChild(locDisplay);
};

const getInventoryByLocationId = async (locationId) => {
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


async function getAllBooksForCurrentLocation() {
  let locationId = localStorage.getItem("UserLocationId");
  const inventory = await getInventoryByLocationId(locationId);
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
    let quantityCell = row.insertCell(4);
    let synopsisCell = row.insertCell(5);
    quantityCell.innerHTML = inventory[i].quantity;
    // synopsisCell.innerHTML = result[i].synopsis;

    let book = await getBookById(inventory[i].bookId);
    idCell.innerHTML = book.id;
    titleCell.innerHTML = book.title;
    authorCell.innerHTML = book.author;
    priceCell.innerHTML = book.price;
  }
};

const getUserCart = async () => {
  let userId = localStorage.getItem("UserId");
  const response = await fetch(
    `https://localhost:44360/api/cart/get/${userId}`
  );
  return response.json();
};

const getInventoryItemByLocationIdBookId = async (locationId, bookId) => {
  const response = await fetch(
    `https://localhost:44360/api/inventory/get/${locationId}/${bookId}`
  );
  if (response.status == 500) {
    alert("Not a valid selection");
  } else {
    return response.json();
  }
};

//TODO add a check to see if the item already exists in the user's cart and 
//update the quantity of that cart item instead of adding an entirely new one
// Adds selected item to user's cart
const addToCart = async () => {
  const userCart = await getUserCart();
  let cartItem = {};
  cartItem.cartId = userCart.id;
  cartItem.bookId = parseInt(document.querySelector("#bookId").value);
  cartItem.quantity = parseInt(document.querySelector("#quantity").value);

  if (parseInt(document.querySelector("#quantity").value) < 1) {
    alert("You can't add 0 books to your cart. That's just silly.");
  } else {
    let locationId = localStorage.getItem("UserLocationId");
    const item = await getInventoryItemByLocationIdBookId(
      locationId,
      cartItem.bookId
    );

    if (cartItem.quantity > item.quantity) {
      alert("That's too many...");
    } else {
      const response = await fetch(
        `https://localhost:44360/api/cartItem/add/`,
        {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify(cartItem),
        }
      );
      const success = response.json();
      if (success) {
        alert("Item added to cart!");
        document.querySelector("#bookId").value = "";
        document.querySelector("#quantity").value = "";
      }
    }
  }
};
