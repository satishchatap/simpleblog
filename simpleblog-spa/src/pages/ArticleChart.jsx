
import React from "react";
import { Typography } from '@material-ui/core';
import articlesService from "../store/articlesService";
import Card from "@material-ui/core/Card";
import CardContent from "@material-ui/core/CardContent";
import Divider from "@material-ui/core/Divider";
import { LineChart, Line, XAxis, YAxis, Label } from 'recharts';

import { grey, green, blueGrey } from "@material-ui/core/colors";

class ArticleChart extends React.Component {
  static displayName = ArticleChart.name;

  
  constructor(props) {
    super(props);

    this.state = {
      articles: []
    }

  }
  componentDidMount() {
    this.props.openIdManager.getUser().then((user) => {
      if (user) {
        articlesService
          .getAllArticles(user)
          .then((response) => {
            this.setState(response.data);
            console.log(response.data);
          })
          .catch((e) => {
            console.log(e);
          });
      }
    });
  }

  render() {
   
const articles = this.state.articles;
    return (
      <Card>
        <CardContent>
          <Typography color="textSecondary" gutterBottom>
            Likes by Article
        </Typography>
          <Divider />
                <LineChart
                  data={articles}
                  margin={{
                    top: 16,
                    right: 16,
                    bottom: 0,
                    left: 24,
                  }}
                >
                  <XAxis dataKey="articleId" stroke={blueGrey}/>
                  <YAxis >
                    <Label
                      angle={270}
                      position="left"
                      style={{ textAnchor: 'middle', fill: grey }}
                    >
                      Likes
                    </Label>
                  </YAxis>
                  <Line type="monotone" dataKey="likeCount"  stroke={green} dot={false} />
                </LineChart>
        </CardContent>
      </Card>

    );
  }
}

export default ArticleChart;