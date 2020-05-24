function solve(selector) {
    let element = document.querySelector(selector);
    element.classList.add('highlight');
    let currentElements = element.children;

    while (currentElements != undefined) {
        let isFound = false;
        for (let child of Array.from(currentElements)) {
            if (child.children.length > 0) {
                currentElements = child.children;
                isFound = true;
                break;
            }
        }

        if (isFound == false) {
            break;
        }
    }

    let smallestElement = Array.from(currentElements)[0];
    if (smallestElement != undefined) {

        smallestElement.classList.add('highlight');
        while (smallestElement != element) {
            {
                smallestElement.parentElement.classList.add('highlight');
                smallestElement = smallestElement.parentElement
            }
        }
    }
}

solve('#wrapper')