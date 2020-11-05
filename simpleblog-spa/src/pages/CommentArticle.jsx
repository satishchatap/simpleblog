import React, { } from "react";
import articlesService from "../store/articlesService";
import { withRouter } from "react-router";
import PageBase from "../components/PageBase";
import { Link } from "react-router-dom";
import Button from "@material-ui/core/Button";
import TextField from "@material-ui/core/TextField";
import { grey } from "@material-ui/core/colors";

class Comment extends React.Component {

  static displayName = Comment.name;

  constructor(props) {
    super(props);
    this.state = {
      articleId: this.props.match.params.articleId,
      description: "",
      submitted: false
    }

    this.handleInputChange = this.handleInputChange.bind(this);
    this.saveComment = this.saveComment.bind(this);
    this.newComment = this.newComment.bind(this);
  }

  handleInputChange = event => {
    const { name, value } = event.target;
    
    this.setState(
      () => {
        return {
          [name]: value
        };
      })
  };

  saveComment = () => {
    this.props.openIdManager.getUser().then((user) => {
      if (user) {
        var bodyFormData = new FormData();
        bodyFormData.append('description', this.state.decription);
        
        articlesService
          .commentArticle(user, this.state.articleId, bodyFormData)
          .then(response => {
            this.setState({
              commentId: response.data.comment.commentId,
              description: response.data.comment.description,
              submitted: true
            });
            console.log(response.data);
          })
          .catch(e => {
            console.log(e);
          });
      }
    })
  };

  newComment = () => {
    this.setState({
      articleId: this.props.match.params.articleId,
      description: "",
      submitted: false
    });
  };

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

      <PageBase title="Comment" navigation="My Accounts / Comment">

        {this.state.submitted ? (
          <div>
            <div style={styles.buttons}>
              <Button
                style={styles.saveButton}
                variant="contained"
                type="submit"
                color="primary"
                onClick={this.newComment}
              >
                Another one
                  </Button>
            </div>
          </div>
        ) : (
            <div>

              <TextField
                hintText="Comment"
                label="Comment"
                fullWidth={true}
                margin="normal"
                value={this.state.description}
                onChange={this.handleInputChange}
                name="description"
                id="description"
                required
              />
              <div style={styles.buttons}>
                <Link to="/">
                  <Button variant="contained">Cancel</Button>
                </Link>

                <Button
                  style={styles.saveButton}
                  variant="contained"
                  type="submit"
                  color="primary"
                  onClick={this.saveComment}
                >
                  Save
                      </Button>
              </div>

            </div>
          )}


      </PageBase>
    );
  }
}

export default withRouter(Comment);