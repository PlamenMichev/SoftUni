const elements = {
    divToAppend: document.querySelector('#root'),
    inputField: document.querySelector('#towns'),
    loadBtn: document.querySelector('#btnLoadTowns'),
};


(async function () {
    const listData = async function () {
        elements.divToAppend.innerHTML = '';
        const townsArgs = elements.inputField.value;
        elements.inputField.value = '';
        const townsArr = townsArgs.split(', ').filter((x) => x !== '');
        let towns = {};
        let count =  1;
        for (const town of townsArr) {
            if (!Object.keys(town).includes(town)) {
                towns[count] = {};
            }

            towns[count].name = town;
            count++;
        }

        console.log(towns)

        const callTemplate = await fetch(`./list-template.hbs`);
        const template = await callTemplate.text();
        const townTemplateCall = await fetch(`./town-template.hbs`);
        const townTemplate = await townTemplateCall.text();
        Handlebars.registerPartial('town', await townTemplate);
        const templateFunc = Handlebars.compile(template);
        const result = templateFunc({ towns });
        elements.divToAppend.innerHTML = result;
    }

    elements.loadBtn.addEventListener('click', await listData);
})();