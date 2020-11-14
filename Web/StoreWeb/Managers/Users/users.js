function GetAllManagers() {
    fetch("https://localhost:44360/api/user/get")
      .then((response) => response.json())
      .then((result) => {
        document
          .querySelectorAll("#managers tbody tr")
          .forEach((element) => element.remove());
        let table = document.querySelector("#managers tbody");
        for (let i = 0; i < result.length; ++i) {
          let row = table.insertRow(table.rows.length);
  
          if (result[i].type == 1) {
            let idCell = row.insertCell(0);
            idCell.innerHTML = result[i].id;
  
            let nameCell = row.insertCell(1);
            nameCell.innerHTML = result[i].name;
  
            let emailCell = row.insertCell(2);
            emailCell.innerHTML = result[i].email;
  
            let usernameCell = row.insertCell(3);
            usernameCell.innerHTML = result[i].username;
  
            let locationCell = row.insertCell(4);
            fetch(
              `https://localhost:44360/api/location/get/${result[i].locationId}`
            )
              .then((response) => response.json())
              .then((result) => {
                locationCell.innerHTML = `${result.city}, ${result.state}`;
              });
          }
        }
      });
  }

  function AddManager() {
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
  
        window.location = "users.html";
      } else if (this.status == 406) {
        alert("Please provide a valid email address");
      } else if (this.status == 409) {
        alert("Username already taken");
      }
    };
  
    xhr.open("POST", "https://localhost:44360/api/user/signup/mgr", true);
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

  //TODO add functionality for these
function EditManager() {}
function RemoveManager() {}
