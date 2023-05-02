FROM node:19
WORKDIR /cache

COPY package.json .
COPY package-lock.json .
RUN npm install --silent

WORKDIR /app
ENV PATH /app/node_modules/.bin:$PATH
COPY . .