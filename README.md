# Cinema Sample Project (DDD)

## Git Folder Structure

The repository's folder structure consists of:

- **doc**: This directory contains project documentation files.
- **docker**: This folder is used to store Docker Compose files, configurations, and some PowerShell scripts.
- **src**: This directory holds the application's source code. The solution file is located within this folder, and for each service, a separate folder has been created.
- **test**: This directory contains tests for each service.

## Cinema Architecture Overview

The approach used is Domain-Driven Design (DDD).

The application's structure is as follows:

- **API**: This directory contains models, controllers, and startup configurations.
- **Application**: This directory contains command and query handlers.
- **Domain**: This directory contains domain entities.
- **Persistence**: This directory manages persistence with EF Core.

## Testing

In the test folder, there is a .jmx file that allows testing endpoints with [JMeter](https://jmeter.apache.org/). Additionally, a unit test project for some domains has been included in the solution.

### Analyzing Tests

Reaching a satisfactory test coverage percentage does not guarantee well-written tests.

A useful tool to check the robustness of our tests is [Stryker](https://stryker-mutator.io/).

In the src solution, there is a RunStryker.ps1 file that allows running test mutators.

Here is an example of the output:

- [Output after the first run](docs/mutation-report.FirstRun.html)
- [Output after the second run and some fixes](docs/mutation-report.SecondRun.html)
