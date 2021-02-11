import React from "react";
import Joi from "joi-browser";
import Form from "./common/form";

class ItemPriceForm extends Form {
  state = {
    data: { type: "", name: "", price: 0 },
    errors: {},
    selectedType: 0,
    test: false,
  };

  componentDidMount() {
    this.setState({
      selectedType: this.props.selectedType,
      data: {
        type: this.props.selectedType,
        name: this.props.selectedName,
        price: this.props.selectedPrice,
      },
    });
  }

  schema = {
    type: Joi.string().required().label("Type"),
    name: Joi.string().required().label("Name"),
    price: Joi.number().required().min(0.01).label("Pricesss"),
  };

  handleTypeChange = (e) => {
    this.setState({ selectedType: e.target.value });
    this.handleChange(e);
  };

  updateData = (name, value) => {
    this.props.updateData(this.props.id, name, value);
  };

  doSubmit = async () => {};

  render() {
    const { items, types, onDelete } = this.props;
    const filtered = items.filter(
      (item) => item.type === parseInt(this.state.selectedType)
    );
    return (
      <div>
        <div className="row">
          <div className="col-3">
            {this.renderSelect("type", "Type", types, "nx")}
          </div>
          <div className="col-6">
            {this.renderSelect("name", "Name", filtered)}
          </div>
          <div className="col-2">
            {this.renderInput("price", "Price", "number")}
          </div>
          <div className="col">
            <button type="button" className="btn btn-danger" onClick={onDelete}>
              x
            </button>
          </div>
        </div>
      </div>
    );
  }
}

export default ItemPriceForm;
