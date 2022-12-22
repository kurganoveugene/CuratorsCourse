const BaseElement = require("./baseelement");
class Checkbox extends BaseElement{

    constructor(locator, name){
        super(locator, name);
    }  
 
    async isCheckBoxSelected(){                
        return (await this.getElement()).isSelected();
    }
  
} module.exports = Checkbox;