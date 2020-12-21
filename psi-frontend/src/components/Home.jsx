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
    return <h1 style = {{marginLeft : "25px",marginTop : "200px",  textalign: "justify"}}>{ jokes}</h1>;
  }
}

export default Home;
