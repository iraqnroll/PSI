import React, { Component } from "react";
import ItemPriceForm from "./itemPriceForm";
import { getItems } from "../services/itemService";
import { getReceiptRaw, updateReceipt } from "../services/receiptService";
import Select from "./common/select";
import {
  updateItemPrice,
  addItemPrice,
  deleteItemPrice,
} from "../services/itemPriceService";

class ReceiptForm extends Component {
  state = {
    types: [],
    items: [],
    data: { itemPrices: [] },
    deleted: [],
    index: "a",
    validate: false,
    shops: [],
  };

  async componentDidMount() {
    const itemPrices = await getReceiptRaw(this.props.match.params.id);
    try {
      const types = [
        { id: 1, name: "Mesos gaminiai" },
        { id: 2, name: "Juros gerybes" },
        { id: 3, name: "Kepiniai" },
        { id: 4, name: "Darzoves" },
        { id: 5, name: "Vaisiai" },
        { id: 6, name: "Pieno produktai" },
        { id: 7, name: "Gerimai" },
        { id: 8, name: "Saldumynai" },
        { id: 9, name: "Uzkandziai" },
      ];
      const shops = [
        { id: 1, name: "Iki" },
        { id: 2, name: "Norfa" },
        { id: 3, name: "Rimi" },
        { id: 4, name: "Lidl" },
        { id: 5, name: "Maxima" },
      ];

      const items = await getItems();
      this.setState({ types, items, data: itemPrices, shops });
      this.validate();
    } catch (ex) {
      this.props.history.replace("/not-found");
    }
  }

  validate() {
    let validate = true;
    this.state.data.shop > 0
      ? this.state.data.itemPrices.forEach((e) =>
          e.price <= 0 || !e.item.id || !e.item.type
            ? (validate = false)
            : (validate = validate)
        )
      : (validate = false);
    this.setState({ validate });
  }

  updateData = (id, name, value) => {
    const data = { ...this.state.data };
    data.itemPrices.map((x) => this.changeData(x, id, name, value));
    this.setState({ data });
    this.validate();
  };
  handleSave = async () => {
    if (this.state.modified)
      await updateReceipt(parseInt(this.state.data.shop), this.state.data.id);
    await this.state.deleted.forEach(async (x) => await deleteItemPrice(x));
    const data = { ...this.state.data };
    const respnse = await data.itemPrices.forEach(
      async (x) => await this.saving(x)
    );
    console.log(respnse);
    //window.location = "/receipts";
  };

  async saving(x) {
    if (x.modified) {
      await updateItemPrice(x.id, x.item.id, x.price, x.receiptId);
    }
    if (x.new) {
      await addItemPrice(x.item.id, x.price, x.receiptId);
    }
  }

  handleAdd = () => {
    const data = { ...this.state.data };
    const index = this.state.index;
    const itemPrice = {
      id: index,
      item: { id: "" },
      new: true,
      type: "",
      price: 0,
      receiptId: this.state.data.id,
    };
    data.itemPrices.push(itemPrice);
    const newIndex = index + "a";
    this.setState({ data, index: newIndex });
    this.validate();
  };

  handleShopChange = ({ currentTarget: input }) => {
    const selectedShop = input.value;
    let data = { ...this.state.data };
    data.shop = selectedShop;
    this.setState({ data, modified: true }, this.validate);
  };

  handleDelete = (id) => {
    let deleted = [...this.state.deleted];
    deleted.push(id);
    const data = { ...this.state.data };
    const filtered = data.itemPrices.filter((itemPrice) => itemPrice.id !== id);
    data.itemPrices = filtered;
    this.setState({ data, deleted });
  };

  changeData(a, id, name, value) {
    if (a.id === id) {
      switch (name) {
        case "name":
          a.item.id = parseFloat(value);
          break;
        case "price":
          a.price = parseFloat(value);
          break;
        case "type":
          a.item.type = parseFloat(value);
          break;
        default:
      }
      !a.new && (a.modified = true);
      return a;
    }
    return a;
  }

  render() {
    const { items, types, data } = this.state;

    return (
      <div>
        <div className="d-flex justify-content-between m-3">
          <h1>Receipt Nr.{this.props.match.params.id}</h1>

          <h2>Shop: </h2>
          <Select
            test={false}
            name="shops"
            value={this.state.data.shop}
            label="Shops"
            options={this.state.shops}
            onChange={this.handleShopChange}
          />

          <div>
            {this.state.validate ? (
              <button
                className="btn btn-primary btn-lg"
                onClick={this.handleSave}
              >
                Save
              </button>
            ) : (
              <button className="btn btn-lg btn-primary" disabled>
                Save
              </button>
            )}
          </div>
        </div>

        {data.itemPrices.map((itemPrice) => (
          <ItemPriceForm
            id={itemPrice.id}
            items={items}
            types={types}
            key={itemPrice.id}
            selectedName={itemPrice.item.id}
            selectedPrice={itemPrice.price}
            selectedType={itemPrice.item.type}
            updateData={this.updateData}
            onDelete={() => this.handleDelete(itemPrice.id)}
          />
        ))}
        {this.state.validate ? (
          <button className="btn btn-secondary btn-lg" onClick={this.handleAdd}>
            +
          </button>
        ) : (
          <button className="btn btn-lg btn-secondary" disabled>
            +
          </button>
        )}
      </div>
    );
  }
}

export default ReceiptForm;
