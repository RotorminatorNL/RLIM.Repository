(() => {
    let selectedMenuItem = document.querySelector(".nav-link.active");
    selectedMenuItem.scrollIntoView({ block: "center", inline: "center" });
})();

function ShowSubItems(event, element) {
    let mainItemsContainer = document.getElementById("MainItemsContainer");
    let mainItemContainer = element;
    let subItemContainer = mainItemContainer.children.SubItems;

    CloseAllMainItemContainers(mainItemContainer.id);

    if (subItemContainer.classList.contains("hide")) {
        OpenMainItemContainer(subItemContainer, mainItemsContainer, mainItemContainer);
    } else {
        if (!ClickedOnSubItem(event.path)) {
            CloseMainItemContainer(subItemContainer, mainItemsContainer, mainItemContainer);
        }
    }
}

function ClickedOnSubItem(path) {
    for (var i = 0; i < path.length; i++) {
        if (path[i].className == "sub-item") {
            return true;
        }
    }
    return false;
}

function CloseAllMainItemContainers(mainItemContainerID) {
    let mainItemContainers = document.getElementsByClassName("main-item");

    for (var i = 0; i < mainItemContainers.length; i++) {
        if (mainItemContainers[i].id != mainItemContainerID) {
            mainItemContainers[i].classList.remove("sub-items-visible");
            mainItemContainers[i].children.SubItems.classList.remove("show");
            mainItemContainers[i].children.SubItems.classList.add("hide");
        }
    }
}

function CloseMainItemContainer(subItemContainer, mainItemsContainer, mainItemContainer) {
    subItemContainer.classList.remove("show");
    subItemContainer.classList.add("hide");
    mainItemsContainer.style.flexDirection = "column";
    mainItemContainer.classList.remove("sub-items-visible");
    mainItemContainer.scrollIntoView({ block: "center", inline: "center" });

    setTimeout(() => {
        mainItemsContainer.style.flexDirection = "row";
    }, 500);
}

function OpenMainItemContainer(subItemContainer, mainItemsContainer, mainItemContainer) {
    mainItemContainer.classList.add("sub-items-visible");
    mainItemsContainer.style.flexDirection = "column";

    mainItemContainer.scrollIntoView({ block: "center", inline: "center" });

    setTimeout(() => {
        subItemContainer.classList.remove("hide");
        subItemContainer.classList.add("show");
        mainItemsContainer.style.flexDirection = "row";

        mainItemContainer.scrollIntoView({ behavior: "smooth", block: "center", inline: "center" });
    }, 500);
}