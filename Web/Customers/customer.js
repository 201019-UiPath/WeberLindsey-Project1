const logOut = () => {
    localStorage.clear(); 
    console.log(localStorage.getItem('Username'));
    window.location = "../Main/index.html"
}