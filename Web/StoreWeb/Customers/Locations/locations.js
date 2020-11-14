function displayLocationOptions() {
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

const updateUserLocation = async () => {
  //TODO remove user's items in their cart when switching locations
  let user = {};
  user.id = parseInt(localStorage.getItem("UserId"));
  user.name = localStorage.getItem("name");
  user.email = localStorage.getItem("email");
  user.username = localStorage.getItem("Username");
  user.password = localStorage.getItem("password");
  user.locationId = parseInt(document.querySelector("#locationId").value);
  console.log(user);

  const response = await fetch(`https://localhost:44360/api/user/edit`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(user),
  });
  const success = response.json();
  if (success) {
    alert("Location changed!");
    document.querySelector("#locationId").value = "";
  }
};
