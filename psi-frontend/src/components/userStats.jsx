import React, { Component } from "react";
import { Doughnut } from "react-chartjs-2";
class UserStats extends Component {
  state = {
    shopFrequency: {
      labels: [],
      datasets: [],
    },
  };

  componentDidMount = () => {
    const shops = ["Iki", "Norfa", "Rimi", "Lidl", "Maxima"];
    const colors = ["#264653", "#2a9d8f", "#e9c46a", "#f4a261", "#e76f51"];

    const shopFrequency = {
      labels: shops,
      datasets: [
        {
          label: "# of Visits",
          data: [12, 19, 3, 5, 2],
          backgroundColor: colors,
          borderWidth: 0,
        },
      ],
    };

    this.setState({ shopFrequency });
  };

  render() {
    return (
      <div>
        <h1>My Statistics</h1>
        <div className="row">
          <div className="col">
            <Doughnut
              data={this.state.shopFrequency}
              options={{
                legend: {
                  position: "right",
                },
              }}
            />
          </div>
          <div className="col">
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
        <div className="row">
          <div className="col">
            <Doughnut
              data={this.state.shopFrequency}
              options={{
                legend: {
                  position: "right",
                },
              }}
            />
          </div>
          <div className="col">
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
      </div>
    );
  }
}

export default UserStats;
