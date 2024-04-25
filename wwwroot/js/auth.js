async function login() {
    var username = document.getElementById('typeUsername').value;
    var password = document.getElementById('typePassword').value;
    if (isEmpty(username) || isEmpty(password)) {
        alert('Felhaszn�l�n�v �s jelsz� megad�sa k�telez�!');
    } else if (!validateEmail(username)) {
        alert('Hib�s felhaszn�l�n�v!');
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