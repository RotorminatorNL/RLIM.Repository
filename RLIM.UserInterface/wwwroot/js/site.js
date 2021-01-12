function OpenMenu() {
    let menuElement = document.getElementsByClassName("side-menu")[0];

    if (menuElement.classList.contains("open")) {
        menuElement.classList.remove("open");
    } else {
        menuElement.classList.add("open");
    }
}