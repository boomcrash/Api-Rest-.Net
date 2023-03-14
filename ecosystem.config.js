module.exports = {
  apps : [{
    name: 'ApiCrochbet',
    script: 'dotnet',
    args: 'run --urls=http://localhost:5000',
    cwd: 'ApiCrochbet',
    watch: true,
    ignore_watch: ["node_modules", "logs"],
    env: {
      ASPNETCORE_ENVIRONMENT: 'Production'
    }
  }]
}