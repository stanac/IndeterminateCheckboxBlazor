function allowChange(id) {
    if (!window.checkboxCache) {
        window.checkboxCache = {}

        window.checkboxCache.allows = {};
    }

    window.checkboxCache.allows[id] = true;
}

function dissalowChange(id) {
    if (window.checkboxCache) {
        delete window.checkboxCache.allows[id];
    }
}

function isChangeAllowed(id) {
    if (window.checkboxCache) {
        return window.checkboxCache.allows[id] || false;
    }
    return false;
}

export function setValue(id, value) {
    let element = document.querySelector(`[data-chb-id="${id}"]`);
    allowChange(id);

    if (element) {
        if (value === null) {
            element.checked = false;
            element.indeterminate = true;
        } else if (value) {
            element.indeterminate = false;
            element.checked = true;
        } else {
            element.indeterminate = false;
            element.checked = false;
        }
    }
}

export function initialize(id) {
    let element = document.querySelector(`[data-chb-id="${id}"]`);

    if (element) {
        element.addEventListener('click', e => {
            var id = e.target.getAttribute("data-chb-id");

            if (id) {
                DotNet.invokeMethodAsync("IndeterminateCheckboxBlazor", "CheckboxChangeRequestAsync", id);
            }

            if (!isChangeAllowed(id)) {
                e.preventDefault();
            }
        });

        dissalowChange(id);
    }
}