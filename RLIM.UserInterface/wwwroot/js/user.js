function ShowSubItems(e) {
    let mainItemsContainer = document.getElementById("MainItemsContainer");
    let mainItemContainer = e;
    let subItemContainer = mainItemContainer.children.SubItems;

    CloseAllMainItemContainers(mainItemContainer.id);

    if (subItemContainer.classList.contains("hide")) {
        mainItemContainer.classList.add("sub-items-visible");
        mainItemsContainer.style.flexDirection = "column";

        mainItemContainer.scrollIntoView({ block: "center", inline: "center" });

        setTimeout(() => {
            subItemContainer.classList.remove("hide");
            subItemContainer.classList.add("show");
            mainItemsContainer.style.flexDirection = "row";

            mainItemContainer.scrollIntoView({ behavior: "smooth", block: "center", inline: "center" });
        }, 500);
    } else {
        subItemContainer.classList.remove("show");
        subItemContainer.classList.add("hide");
        mainItemsContainer.style.flexDirection = "column";
        mainItemContainer.classList.remove("sub-items-visible");

        setTimeout(() => {
            mainItemsContainer.style.flexDirection = "row";
        }, 500);
    }
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