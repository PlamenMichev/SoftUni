function focus() {
    let sections = Array.from(document.querySelectorAll('div div input'));

    [...sections].forEach(function(d) {
        d.addEventListener('focus', function(i) {
            this.parentNode.classList.add('focused');
            //this.classList.add('focused');
        });

        d.addEventListener('blur', function(i) {
            this.parentNode.classList.remove('focused');
            //this.classList.add('focused');
        });
    });
}