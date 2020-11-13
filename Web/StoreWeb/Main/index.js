
function SignIn() {
    let user = {};
    user.username = document.querySelector('#username').value;
    user.password = document.querySelector('#password').value;

    let xhr = new XMLHttpRequest();
    
    xhr.onreadystatechange = function() {
        if(this.readyState == 4 && this.status > 199 && this.status < 300) {
            document.querySelector('#username').value = '';
            document.querySelector('#password').value = '';
            console.log('Success!');

            fetch(`https://localhost:44360/api/user/get/${user.username}`)
            .then(response => response.json())
            .then(result => {              
                sessionStorage.setItem('Username', result.username);
                sessionStorage.setItem('UserId', result.id);
                sessionStorage.setItem('UserType', result.type);
                //UserType 0 == Customer
                //UserType 1 == Manager

                if(result.type == 0) {
                    //If successful login and user.type == customer
                    window.location = "../customers/customer.html"
                } else if(result.type == 1) {
                    //If successful login and user.type == manager
                    window.location = "../managers/manager.html"
                } else {
                    console.log('foiled again');
                }
            });  
        }
        else if(this.status == 403) {
            alert('Invalid username or password');
        }

    };

    xhr.open("POST", 'https://localhost:44360/api/user/signin', true);
    xhr.setRequestHeader('Content-type', 'application/json');
    xhr.send(JSON.stringify(user));
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
        else if(this.status == 406) {
            alert('Please provide a valid email address');
        }
        else if(this.status == 409) {
            alert('Username already taken');
        }
        
    };

    xhr.open("POST", 'https://localhost:44360/api/user/signup', true);
    xhr.setRequestHeader('Content-type', 'application/json');
    xhr.send(JSON.stringify(user));
}
