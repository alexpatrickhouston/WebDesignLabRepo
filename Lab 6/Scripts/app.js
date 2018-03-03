function display() {
    alert("displaying");
    var firstname = document.getElementById("FName").value;
    var lastname = document.getElementById("LName").value;
    var age = document.getElementById("age").value;
    var summary = firstname + " " + lastname + " is " + age + " years old.";
    document.getElementById("summary").innerText = summary;
}
function validate() {
    if (document.getElementById("FName").value === "") {
        alert("First Name must be filled out");
        return false;
    }
    if (document.getElementById("LName").value === "") {
        alert("Last Name must be filled out");
        return false;
    }
    if (document.getElementById("age").value === "") {
        alert("age must be filled out");
        return false;
    }
}