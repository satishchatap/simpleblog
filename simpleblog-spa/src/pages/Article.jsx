import React, {  } from "react";
import articlesService from "../store/articlesService";
import { withRouter } from "react-router";
import { Typography, IconButton , Tooltip} from '@material-ui/core';
import Button from '@material-ui/core/Button';
import { Link } from 'react-router-dom';
import { grey } from "@material-ui/core/colors";
import Paper from '@material-ui/core/Paper';
import Grid from '@material-ui/core/Grid';
import Avatar from '@material-ui/core/Avatar';
import { makeStyles } from '@material-ui/core/styles';
import ThumbUpIcon from '@material-ui/icons/ThumbUp';
import AddCommentIcon from '@material-ui/icons/AddComment';
import Card from "@material-ui/core/Card";
import CardContent from "@material-ui/core/CardContent";
import Divider from "@material-ui/core/Divider";
const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
    overflow: 'hidden',
    padding: theme.spacing(0, 3),
  },
  paper: {
    maxWidth: 400,
    margin: `${theme.spacing(1)}px auto`,
    padding: theme.spacing(2),
  },
}));

class Article extends React.Component {

  static displayName = Article.name;
  
  constructor(props) {
    super(props);

    this.state = {
      error:false,
      message:"",
      articleId: this.props.match.params.articleId,
      article: {
        likes: [],
        comments: [],
        likeCount:0,
        commentCount:0,
      }
    }

    this.fetchData(this.state.articleId);
  }

  getAvatar = value =>{
    return value===undefined ? "": value.substring(0,2).toUpperCase();
  }

  fetchData = id => {
    this.props.openIdManager.getUser().then((user) => {
      if (user) {
        articlesService
          .getArticle(user, id)
          .then((response) => {
            this.setState(response.data);
            console.log(response.data);            
          })
          .catch((e) => {
            console.log(e);
          });
      }
    });
  };

  saveLike = () => {
    this.props.openIdManager.getUser().then((user) => {
      if (user) {
        articlesService
          .likeArticle(user, this.state.articleId)
          .then(response => {
            this.setState({              
              article:{...this.state.article, likeCount:this.state.article.likeCount+1}
            });
            console.log(response.data);
          })
          .catch(e => {
            console.log(e);
          });
      }
    })
  };
  componentDidMount() {

  }

  render() {

    const styles = {
      toggleDiv: {
        marginTop: 20,
        marginBottom: 5
      },
      toggleLabel: {
        color: grey[400],
        fontWeight: 100
      },
      buttons: {
        marginTop: 30,
        float: "right"
      },
      saveButton: {
        marginLeft: 5
      }
    };
    return (

      <React.Fragment>
             <div className={useStyles.root}>
      <Paper className={useStyles.paper}>
        <Grid container spacing={2}>
          <Grid item>
             <Avatar>{this.getAvatar(this.state.article.author)}</Avatar>
          </Grid>
          <Grid item xs={12} sm container>
            <Grid item xs container direction="column" spacing={2}>
              <Grid item xs>
                <Typography gutterBottom variant="subtitle1">
                  {this.state.article.title}
                </Typography>
                <Typography variant="body2" gutterBottom>
                  {this.state.article.summary}
                </Typography>
                <Typography variant="body2" color="textSecondary">
                  {this.state.article.body}
                </Typography>
              </Grid>
              <Grid item>
                <Tooltip title={this.state.article.likeCount} >
                  <IconButton aria-label="like">
                    <ThumbUpIcon onClick={this.saveLike} variant="contained" color="primary">Like</ThumbUpIcon>
                  </IconButton>
                </Tooltip>                 
                <Tooltip title={this.state.article.commentCount} >
                  <IconButton aria-label="comment" component={Link} to={`/articles/${this.state.articleId}/Comment`}>
                    <AddCommentIcon variant="contained" color="primary">Comment</AddCommentIcon>
                  </IconButton>
                </Tooltip>
              </Grid>
            </Grid>
          </Grid>
        </Grid>
        
            <div style={styles.buttons}>

        
          <Button component={Link} to={`/CreateArticle/${this.state.articleId}`} variant="contained" color="primary">
            Edit
            </Button>

          <Button component={Link} to={`/articles/${this.state.articleId}/Delete`} variant="contained" color="secondary">
            Delete
            </Button>

        </div>
        <Grid container spacing={2} sm={12}>
                {
                this.state.article.comments.map((comment) => {
                  return (
                    <Grid item  direction="row" spacing={2}>
                       <Card>
                        <CardContent>
                          <Typography color="textSecondary" gutterBottom>
                            {comment.author}
                          </Typography>
                          <Divider />
                          <div> {comment.desctiption}</div>
                          </CardContent></Card>
                    </Grid>
                    
                  )
                })
              }
            
        </Grid>
      </Paper>
    </div>
      </React.Fragment>
    );
  }
}

export default withRouter(Article);
