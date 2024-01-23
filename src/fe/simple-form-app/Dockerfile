# Stage 1: Compile and Build angular codebase

# Use official node image as the base image
FROM node:20.11.0 as build

#Accepting build-arg to create environment specific build
#it is useful when we have multiple environment (e.g: dev, tst, staging, prod)
#default value is production
ARG build_env=production

# Set the working directory
WORKDIR /app

# Install all the dependencies

COPY . .
RUN npm cache clean --force
RUN npm install
RUN npm run build --prod

# Stage 2: Serve app with nginx server

# Use official nginx image as the base image
FROM nginx:latest

# Copy the build output to replace the default nginx contents.
COPY --from=build /app/dist/simple-form-app/browser /usr/share/nginx/html
COPY /nginx.conf  /etc/nginx/conf.d/default.conf

# Expose port 80
EXPOSE 80