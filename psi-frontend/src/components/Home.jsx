import React, { Component } from "react";
import { getJoke } from "../services/jokeService";
class Home extends Component {
  async componentDidMount() {
    const joke = await getJoke();
    console.log(joke.content);
    this.setState({ jokes: joke.content });
  }
  state = {jokes : ""};
  render() {
    const { jokes } = this.state;
    return (<div style={{ marginLeft: "25px", marginTop: "200px", textalign: "justify" }}>
      <h1>Joke Of The Day: </h1>
      
      <h1 >{jokes}</h1>
      </div>);
  }
}

export default Home;
