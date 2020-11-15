const getUser = async (username) => {
  const response = await fetch(
    `https://localhost:44360/api/user/get/${username}`
  );
  return response.json();
};

const SignIn = async () => {
  let user = {};
  user.username = document.querySelector("#username").value;
  user.password = document.querySelector("#password").value;

  const response = await fetch(`https://localhost:44360/api/user/signin`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(user),
  });
  const success = response.json();
  if (success) {
    const signedInUser = await getUser(user.username);
    localStorage.setItem("UserId", signedInUser.id);
    localStorage.setItem("name", signedInUser.name);
    localStorage.setItem("email", signedInUser.email);
    localStorage.setItem("Username", signedInUser.username);
    localStorage.setItem("password", signedInUser.password);
    localStorage.setItem("UserType", signedInUser.type);
    localStorage.setItem("UserLocationId", signedInUser.locationId);
    // localStorage.setItem("User", JSON.stringify(signedInUser));

    document.querySelector("#username").value = "";
    document.querySelector("#password").value = "";

    //UserType 0 == Customer
    //UserType 1 == Manager
    if (signedInUser.type == 0) {
      //If successful login and user.type == customer
      window.location = "../customers/customer.html";
    } else if (signedInUser.type == 1) {
      //If successful login and user.type == manager
      window.location = "../managers/manager.html";
    } else {
      console.log("foiled again");
    }
  } else {
    alert("Invalid username or password");
  }
};

function SignUp() {
  let user = {};
  user.name = document.querySelector("#name").value;
  user.email = document.querySelector("#email").value;
  user.username = document.querySelector("#username").value;
  user.password = document.querySelector("#password").value;
  user.locationId = parseInt(document.querySelector("#locationId").value);

  let xhr = new XMLHttpRequest();

  xhr.onreadystatechange = function () {
    if (this.readyState == 4 && this.status > 199 && this.status < 300) {
      alert("New User Added!");
      document.querySelector("#name").value = "";
      document.querySelector("#email").value = "";
      document.querySelector("#username").value = "";
      document.querySelector("#password").value = "";

      window.location = "signIn.html";
    } else if (this.status == 406) {
      alert("Please provide a valid email address");
    } else if (this.status == 409) {
      alert("Username already taken");
    }
  };

  xhr.open("POST", "https://localhost:44360/api/user/signup/cust", true);
  xhr.setRequestHeader("Content-type", "application/json");
  xhr.send(JSON.stringify(user));
}

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
