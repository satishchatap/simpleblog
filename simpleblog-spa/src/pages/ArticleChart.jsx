
import React from "react";
import { Typography } from '@material-ui/core';
import articlesService from "../store/articlesService";
import Card from "@material-ui/core/Card";
import CardContent from "@material-ui/core/CardContent";
import Divider from "@material-ui/core/Divider";

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
    var Chartist = require("chartist");
    var labelVal=[];
    var seriesVal=[];
    for (var i in this.state.articles) {
        labelVal.push(this.state.articles[i].articleId);
        seriesVal.push(this.state.articles[i].likeCount);
      }
    
    var data = {
        labels: labelVal,
        series: [
          seriesVal
        ]
      };
 
   
    new Chartist.Line('.ct-chart', data, {
        low: 0,
            chartPadding: {
              top: 40,
              right: 0,
              bottom: 0,
              left: 0
            },
        showArea: true
      });
    return (
      <Card>
        <CardContent>
          <Typography color="textSecondary" gutterBottom>
            Likes by Articles
          </Typography>
          <Divider />
          <div className="ct-chart"></div>
        </CardContent>
      </Card>

    );
  }
}

export default ArticleChart;