FROM postgres:latest

# Copy initialization scripts (if any)
# COPY ./init-scripts /docker-entrypoint-initdb.d/

# Expose the default PostgreSQL port
EXPOSE 5432

# Command to run the PostgreSQL server
CMD ["postgres"]