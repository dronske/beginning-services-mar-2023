FROM node:16.18-slim AS build
WORKDIR /dist/src/app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build
FROM nginx:latest AS ngi
COPY --from=build /dist/src/app/dist/frontend /usr/share/nginx/html
COPY /nginx.conf  /etc/nginx/conf.d/default.conf
EXPOSE 80