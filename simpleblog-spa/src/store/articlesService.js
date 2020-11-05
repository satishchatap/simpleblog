import http from "./http-common"

const getArticles = (user) => {
  return http
    .createAxios(user)
    .get("/api/v1/articles");
};
const getAllArticles = (user) => {
  return http
    .createAxios(user)
    .get("/api/v1/articles/getall");
};

const getArticle = (user, id) => {
  return http
    .createAxios(user)
    .get(`/api/v1/articles/${id}`);
};

const createArticle = (user,data) => {
  return http
    .createAxios(user)
    .post(`/api/v1/articles`,data);
};

const commentArticle = (user,id, data) => {
  console.log(user);
  return http
    .createAxios(user)
    .patch(`/api/v1/comments/${id}/comment`, data);
};

const likeArticle = (user,id, data) => {
  return http
    .createAxios(user)
    .patch(`/api/v1/likes/${id}/like`, data);
};

const deleteArticle = (user, id) => {
  return http
    .createAxios(user)
    .delete(`/api/v1/articles/${id}`);
};

const editArticle = (user, id) => {
  return http
    .createAxios(user)
    .patch(`/api/v1/articles/${id}`);
};
export default {
  getArticles,
  getArticle,
  commentArticle,
  likeArticle,
  deleteArticle,
  createArticle,
  editArticle,
  getAllArticles
};