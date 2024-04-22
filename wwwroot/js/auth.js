async function login() {
    var username = document.getElementById('typeUsername').value;
    var password = document.getElementById('typePassword').value;
    if (isEmpty(username) || isEmpty(password)) {
        alert('Felhasználónév és jelszó megadása kötelezõ!');
    } else if (!validateEmail(username)) {
        alert('Hibás felhasználónév!');
    } else {
        var data = {
            username: username,
            password: password
        };
        await postData("auth/login", data, false)
            .then(async (data) => {
                if (await data.token) {
                    localStorage.setItem("data", JSON.stringify(data));
                    window.location.href = "index.html";
                } else {
                    alert(await data.Message);
                }
            });
    }
}

function isEmpty(str) {
    return (!str || 0 === str.length);
}

function validateUsername(username) {
    var re = /\S+@\S+\.\S+/;
    return re.test(username);
}