
function SignIn() {
    //TODO fix this
    let user = {};
    user.username = document.querySelector('#username');
    user.password = document.querySelector('#password');

    let xhr = new XMLHttpRequest();

    xhr.onreadystatechange = function() {
        if(this.readyState == 4 && this.status > 199 && this.status < 300) {
            document.querySelector('#username').value = '';
            document.querySelector('#password').value = '';
            console.log('Success!');

            if(user.type == 'customer') {
                //If successful login and user.type == customer
                window.location = "customer.html"
            } else if(user.type == 'manager') {
                //If successful login and user.type == manager
                window.location = "manager.html"
            } else {
                console.log('foiled again');
            }
        }
        else {
            alert('Invalid username or password');
        }
    };

    xhr.open("POST", 'https://localhost:44360/api/user/signin', true);
    xhr.setRequestHeader('Content-type', 'application/json');
    xhr.send(JSON.stringify(user));

    // fetch(`https://localhost:44360/api/user/get/${username}`)
    // .then(response => response.json())
    // .then(result => {
    //     console.log(result);
    // });
}


function SignUp() {
    let user = {}
    user.name = document.querySelector('#name').value;
    user.email = document.querySelector('#email').value;
    user.username = document.querySelector('#username').value;
    user.password = document.querySelector('#password').value;
    user.locationId = 1; //TODO temporary value

    let xhr = new XMLHttpRequest();

    xhr.onreadystatechange = function() {
        if(this.readyState == 4 && this.status > 199 && this.status < 300) {
            alert('New User Added!')
            document.querySelector('#name').value = '';
            document.querySelector('#email').value = '';
            document.querySelector('#username').value = '';
            document.querySelector('#password').value = '';

            window.location = "signIn.html";
        }
    };

    xhr.open("POST", 'https://localhost:44360/api/user/signup', true);
    xhr.setRequestHeader('Content-type', 'application/json');
    xhr.send(JSON.stringify(user));
}
