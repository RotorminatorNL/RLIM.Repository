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
        if (event.view.screen.width > 1024) {
            FancyOpenMainItemContainer(subItemContainer, mainItemsContainer, mainItemContainer);
        } else {
            NormalOpenMainItemContainer(subItemContainer, mainItemContainer);
        }
    } else {
        if (event.view.screen.width > 1024) {
            if (!ClickedOnSubItemContainer(event.path)) {
                FancyCloseMainItemContainer(subItemContainer, mainItemsContainer, mainItemContainer);
            }
        } else {
            if (!ClickedOnSubItem(event.path)) {
                NormalCloseMainItemContainer(subItemContainer, mainItemContainer);
            }
        }
    }
}

function ClickedOnSubItemContainer(path) {
    for (var i = 0; i < path.length; i++) {
        if (path[i].id == "SubItems") {
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

// Big screen
function FancyCloseMainItemContainer(subItemContainer, mainItemsContainer, mainItemContainer) {
    subItemContainer.classList.remove("show");
    subItemContainer.classList.add("hide");
    mainItemsContainer.style.flexDirection = "column";
    mainItemContainer.classList.remove("sub-items-visible");
    mainItemContainer.scrollIntoView({ block: "center", inline: "center" });

    setTimeout(() => {
        mainItemsContainer.style.flexDirection = "row";
    }, 500);
}

// Small screen
function NormalCloseMainItemContainer(subItemContainer, mainItemContainer) {
    subItemContainer.classList.add("hide");
    mainItemContainer.classList.remove("sub-items-visible");
    subItemContainer.classList.remove("show");
}

// Big screen
function FancyOpenMainItemContainer(subItemContainer, mainItemsContainer, mainItemContainer) {
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

// Small screen
function NormalOpenMainItemContainer(subItemContainer, mainItemContainer) {
    subItemContainer.classList.remove("hide");
    mainItemContainer.classList.add("sub-items-visible");
    subItemContainer.classList.add("show");
}

function ChangeStatus() {
    alert("xd");
}