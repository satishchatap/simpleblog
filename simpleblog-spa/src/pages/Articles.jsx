
import React from "react";
import { Typography } from '@material-ui/core';
import articlesService from "../store/articlesService";
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Card from "@material-ui/core/Card";
import CardContent from "@material-ui/core/CardContent";
import Divider from "@material-ui/core/Divider";

class Articles extends React.Component {
  static displayName = Articles.name;

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
          .getArticles(user)
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
    return (

      <Card>
        <CardContent>
          <Typography color="textSecondary" gutterBottom>
            Articles
        </Typography>
          <Divider />
          <Table>
            <TableHead>
              <TableRow> 
                <TableCell></TableCell>
                <TableCell>Title</TableCell>
                <TableCell>Likes</TableCell>
                <TableCell>Comments</TableCell>
                <TableCell>Author</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {
                this.state.articles.map((article) => {
                  return (
                    <TableRow key={article.articleId}>
                      <TableCell><a className="text-dark" href={`/articles/${article.articleId}`}>Show</a></TableCell>
                      <TableCell>{article.title}</TableCell>
                      <TableCell>{article.likeCount}</TableCell>
                      <TableCell>{article.commentCount}</TableCell>
                      <TableCell>{article.author}</TableCell>
                    </TableRow>
                  )
                })
              }
            </TableBody>
          </Table>
        </CardContent>
      </Card>

    );
  }
}

export default Articles;