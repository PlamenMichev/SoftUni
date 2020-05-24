function extensibleObject() {
    let obj = {
        extend: function (otherObj) {
            for (let key of Object.keys(otherObj)) {
                if (typeof otherObj[key] == 'function') {
                    Object.keys(this.__proto__).push(key);
                    this.__proto__[key] = otherObj[key];
                } else {
                    Object.keys(this).push(key);
                    this[key] = otherObj[key];
                }
            }
        }
    }

    return obj;
}

extensibleObject();