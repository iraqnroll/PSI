import React, { Component } from "react";
import Select from "./common/select";
import { getItems } from "../services/itemService";
import { Line } from "react-chartjs-2";
import { getPriceHistory } from "../services/itemPriceService";

class PriceHistory extends Component {
  state = {
    selectedType: 0,
    types: [],
    selectedItem: 0,
    items: [],
    priceHistory: [],
  };

  async componentDidMount() {
    const items = await getItems();
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
    this.setState({ types, items });
  }

  handleTypeChange = (e) => {
    this.setState({ selectedType: e.target.value });
  };

  handleItemChange = (e) => {
    this.setState({ selectedItem: e.target.value });
  };

  handleFind = async () => {
    const priceHistory = await getPriceHistory(this.state.selectedItem);
    this.setState({ priceHistory });
  };

  render() {
    const { items, types, selectedType, selectedItem } = this.state;
    const filtered = items.filter(
      (item) => item.type === parseInt(this.state.selectedType)
    );
    return (
      <div className="Box_content pr-5 pb-4">
        <h1
          className="mt-3"
          style={{
            textAlign: "center",
            fontSize: 40,
            color: "#616161",
            padding: 10,
          }}
        >
          Price History
        </h1>
        <div className="col shadow p-3 mt-3 bg-white rounded">
          <div className="row p-3">
            <div className="col-3 ">
              <Select
                test={false}
                name="types"
                value={selectedType}
                label="Types"
                options={types}
                onChange={this.handleTypeChange}
              />
            </div>
            <div className="col-7">
              <Select
                test={false}
                name="items"
                value={selectedItem}
                label="Items"
                options={filtered}
                onChange={this.handleItemChange}
              />
            </div>
            <div className="col">
              {selectedItem > 0 && selectedType > 0 ? (
                <button
                  className="btn btn-secondary "
                  onClick={this.handleFind}
                >
                  Find
                </button>
              ) : (
                <button className="btn btn-secondary  " disabled>
                  Find
                </button>
              )}
            </div>
          </div>
          <Line
            data={this.state.priceHistory}
            options={{
              scales: {
                xAxes: [
                  {
                    type: "time",
                  },
                ],
                yAxes: [
                  {
                    ticks: {
                      beginAtZero: true,
                    },
                  },
                ],
              },
            }}
          />
        </div>
      </div>
    );
  }
}

export default PriceHistory;
