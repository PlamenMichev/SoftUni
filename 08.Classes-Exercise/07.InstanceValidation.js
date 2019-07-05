class CheckingAccount {
    constructor(clientId, email, firstName, lastName) {
        this.clientId = clientId;
        this.email = email;
        this.firstName = firstName;
        this.lastName = lastName;
    }

    set clientId(value) {
        let currentRegex = /[0-9]+/g;
        if (typeof value !== 'string' || value.match(currentRegex) === null || value.length != 6) {
            throw TypeError('Client ID must be a 6-digit number');
        }
    }

    set email(value) {
        let emailRegex = /[A-Za-z]+@[A-Za-z\t]+/g;
        if (value.match(emailRegex) === null) {
            throw TypeError('Invalid e-mail');
        }
    }

    set firstName(value) {
        let regex = /[A-Za-z]+/g;
        console.log(value.match(regex))
        if (value.length < 3 || value.length > 20) {
            throw TypeError('First name must be between 3 and 20 characters long');
        }

        if (value.match(regex) === null) {
            throw TypeError('First name must contain only Latin characters');            
        }
    }

    set lastName(value) {
        let regex = /[A-Za-z]+/g;
        if (value.length < 3 || value.length > 20) {
            throw TypeError('Last name must be between 3 and 20 characters long');
        }

        if (value.match(regex) === null) {
            throw TypeError('Last name must contain only Latin characters');            
        }
    }
}

try {
    let acc = new CheckingAccount('131455', 'ivan@some.com', 'Ivan', 'P3trov')
} catch (error) {
    console.log(error.message)
}