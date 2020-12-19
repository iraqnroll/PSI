import React, { Component } from "react";
import { Doughnut, Line } from "react-chartjs-2";
import {
  getShopFrequency,
  getItemsFrequency,
  getDates,
  formatDate,
} from "../services/userStatsService";
class UserStats extends Component {
  state = {
    shopFrequency: {
      labels: [],
      datasets: [],
    },
    moneySpent: {
      labels: [],
      datasets: [],
    },

    itemFrequency: {
      labels: [],
      datasets: [],
    },

    iMoneySpent: {
      labels: [],
      datasets: [],
    },

    monthFrequency: {
      labels: [],
      datasets: [],
    },
  };

  componentDidMount = async () => {
    const shopsFrequency = await getShopFrequency();
    const itemsFrequency = await getItemsFrequency();
    const monthFrequency = await getDates();

    const shops = shopsFrequency.map((x) => x.name);
    const frequency = shopsFrequency.map((x) => x.shopFrequency);
    const spent = shopsFrequency.map((x) => x.moneySpent);

    const items = itemsFrequency.map((x) => x.frequentItem.name);
    const iFrequency = itemsFrequency.map((x) => x.itemFrequency);
    const iSpent = itemsFrequency.map((x) => x.moneySpent);

    const colors = ["#264653", "#2a9d8f", "#e9c46a", "#f4a261", "#e76f51"];

    const shopFrequency = {
      labels: shops,
      datasets: [
        {
          label: "# of Shops",
          data: frequency,
          backgroundColor: colors,
          borderWidth: 0,
        },
      ],
    };

    const moneySpent = {
      labels: shops,
      datasets: [
        {
          label: "# of Shops",
          data: spent,
          backgroundColor: colors,
          borderWidth: 0,
        },
      ],
    };

    const itemFrequency = {
      labels: items,
      datasets: [
        {
          label: "# of Shops",
          data: iFrequency,
          backgroundColor: colors,
          borderWidth: 0,
        },
      ],
    };

    const iMoneySpent = {
      labels: items,
      datasets: [
        {
          label: "# of Shops",
          data: iSpent,
          backgroundColor: colors,
          borderWidth: 0,
        },
      ],
    };

    this.setState({
      shopFrequency,
      moneySpent,
      itemFrequency,
      iMoneySpent,
      monthFrequency,
    });
  };

  render() {
    return (
      <div>
        <h1
          style={{
            textAlign: "center",
            fontSize: 40,
            color: "#616161",
            padding: 10,
          }}
        >
          My Statistics
        </h1>
        <div className="row mt-4">
          <div className="col shadow p-3 mb-3 mr-5 bg-white rounded">
            <h2
              className="mb-4"
              style={{ textAlign: "center", fontSize: 20, color: "#616161" }}
            >
              Most frequently visited shops
            </h2>
            <div className="mb-4">
              <Doughnut
                data={this.state.shopFrequency}
                options={{
                  legend: {
                    position: "right",
                  },
                }}
              />
            </div>
          </div>
          <div className="col shadow p-3 mb-3  bg-white rounded">
            <h2
              className="mb-4"
              style={{ textAlign: "center", fontSize: 20, color: "#616161" }}
            >
              Money spent (Euro)
            </h2>
            <div className="mb-4">
              <Doughnut
                data={this.state.moneySpent}
                options={{
                  legend: {
                    position: "right",
                  },
                }}
              />
            </div>
          </div>
        </div>
        <div className="row mt-4">
          <div className="col shadow p-3 mb-3 mr-5 bg-white rounded">
            <h2
              className="mb-4"
              style={{ textAlign: "center", fontSize: 20, color: "#616161" }}
            >
              Top 5 Most frequently bought items
            </h2>
            <div className="mb-4 ml-4">
              <Doughnut
                width={350}
                height={350}
                data={this.state.itemFrequency}
                options={{
                  responsive: false,
                  legend: {
                    position: "bottom",
                  },
                }}
              />
            </div>
          </div>
          <div className="col shadow p-3 mb-3 bg-white rounded">
            <h2
              className="mb-4"
              style={{ textAlign: "center", fontSize: 20, color: "#616161" }}
            >
              Top 5 Total cost (Eur)
            </h2>
            <div className="mb-4 ml-4">
              <Doughnut
                width={350}
                height={350}
                data={this.state.iMoneySpent}
                options={{
                  responsive: false,
                  legend: {
                    position: "bottom",
                  },
                }}
              />
            </div>
          </div>
        </div>
        <div className="row mt-4">
          <div className="col shadow p-3 mb-5 bg-white rounded">
            <h2
              className="mb-4"
              style={{ textAlign: "center", fontSize: 20, color: "#616161" }}
            >
              Shopping frequecy per month
            </h2>
            <div className="mb-4 ml-4">
              <Line
                data={this.state.monthFrequency}
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
                          stepSize: 1,
                        },
                      },
                    ],
                  },
                }}
              />
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default UserStats;
