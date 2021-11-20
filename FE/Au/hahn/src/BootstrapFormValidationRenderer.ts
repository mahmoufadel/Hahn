export class BootstrapFormValidationRenderer {

  render(instruction) {
    for (let ins of instruction.unrender) {
      for (let element of ins.elements) {
        this.remove(element, ins.result);
      }
    }

    for (let ins of instruction.render) {
      for (let element of ins.elements) {
        if(!ins.result.valid) this.add(element, ins.result);
      }
    }
  }

  add(element, error) {
    const formGroup = element.closest('.form-group');
    const formcontrol = element.closest('.form-control');
    if (!formGroup) {
      return;
    }
    
    formGroup.classList.add('is-invalid');
    formcontrol.classList.add('is-invalid');

    const message = document.createElement('span');
    message.className = 'help-block validation-message';
    message.textContent = error.message;
    message.id = `bs-validation-message-${error.id}`;
    element.parentNode.insertBefore(message, element.nextSibling);
  }

  remove(element, error) {
    const formGroup = element.closest('.form-group');
    const formcontrol = element.closest('.form-control');
    if (!formGroup) {  return;   }

    const message = formGroup.querySelector(`#bs-validation-message-${error.id}`);
    if (message) {
      element.parentNode.removeChild(message);
      
      if (formGroup.querySelectorAll('.help-block.validation-message').length === 0) {    
        formGroup.classList.remove('is-invalid');
        formcontrol.classList.remove('is-invalid');
      }
     
    }
  }
}
