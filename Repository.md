# Repository _Standard and Rules_

Welcome to the Project Q repository! This document outlines the rules and standards for branch naming and development workflow.

## Branch Naming Convention

In order to maintain consistency and clarity across the repository, we follow a specific branch naming convention:

- `research/<research-name>`: Used for new research and development.
- `investigation/<investigation_name_and_ticket#>`: Used when investigating the reported issues.
- `workaround/<workaround_name_and_ticket#>`: Used for quick workaround solutions to critical issues.
- `development`: The main development branch where research, investigation, and workaround are integrated for testing.
- `master`: The stable branch reflecting the latest code.

## Branch Descriptions

- `research/<research_name>`: Use this branch for in-depth research and development of new features of SDK and platform features. Upon completion, a pull request should be submitted to the `development` branch for review.
- `investigation/<investigation_name_and_ticket#>`: Use this branch when investigating the reported issues. Once the investigation is done, create a pull request and let the team check this investigation as well to validate it. Most of the time this branch will not be merge in the development branch, but will be a base ticket for a new __workaround__ branch.
- `workaround/<workaround_name_and_ticket#>`: Use this branch when creating a workaround solutions to the created issues. Upon completion, a pull request should be submitted to the `development` branch for team review.
- `development`: The integration branch for testing new research and workaround. Pull requests from research and workaround branches should target this branch. Once the changes are thoroughly tested, they will be merged into both `master` and `development`.
- `master`: The stable branch containing the latest production-ready code. Merge only from the `development` branch after extensive testing and validation.

## Workflow

1. Create a new branch based on the type of work:
   - `research/<research-name>`
   - `investigation/<investigation_name_and_ticket#>`
   - `workaround/<workaround_name_and_ticket#>`
2. Make changes and commits in the branch. If you forget to switch branch and make a lot of changes. Stop for a moment, and don't panic. Do `git stash`, create a new branch `git checkout -b research/<research-name>`. Once branch is created, just type `git stash pop`, then there are your changes.
3. Open a pull request from your branch to the `development` branch for validation and code review.

4. After review and approval, the code will be merged into the `development` branch.
5. Regularly merge changes from `development` to `master` for stable production releases.

Remember to follow our coding guidelines, write clear commit messages, and ensure your code passes all tests before opening a pull request.

## Code Organization

To promote a well-structured and organized repository, it's important to ensure that changes are segregated within their respective folders and namespaces. This practice minimizes conflicts and enhances collaboration, especially when multiple contributors are working on similar research or development efforts.

### Folder and Namespace Convention

When making changes, please adhere to the following guidelines:

- Create a dedicated folder for each major feature, research effort, or area of development.
- Namespace your code within the folder to avoid naming collisions.
- Use meaningful names for folders and namespaces to provide clear context.

For example: 

You created a branch name `<research/first-hand-physics>`. You must also use this branch name when naming your namespaces and folder.

```
/research/first-hand-physics/scripts/HandInteraction.cs


namespace research/first-hand-physics {
    public class HandInteraction : MonoBehaviour { }
}

```

If you're not familiar with namespaces yet, please refer [here](https://docs.unity3d.com/Manual/Namespaces.html).

By organizing your code in this manner, you help prevent unintended interactions between different changes and facilitate a smoother collaboration experience.

## Collaboration Guidelines

If you find that multiple team members are working on similar or overlapping research topics, consider the following collaboration guidelines:

1. **Communication**: Before starting a new research or development effort, communicate your intentions with the team. This will help identify potential overlaps and allow for adjustments.

2. **Shared Knowledge**: If multiple contributors are working on similar research, encourage sharing findings and insights with the team. This fosters collaboration and may lead to more efficient solutions.

3. **Regular Updates**: Provide regular updates on your progress to keep the team informed about your work. This helps in identifying any potential conflicts early on.

Remember, our goal is to work together smoothly and efficiently, leveraging each other's expertise to achieve the best possible outcomes.

## Conclusion

Following these branch naming conventions and workflow practices will help us maintain an organized and efficient development process. If you have any questions or need assistance, feel free to reach out to the team.

Organizing code within folders and namespaces, along with effective communication and collaboration, will lead to a more structured and productive development environment. Let's continue to work together to create high-quality software!

Happy coding!


![supportninja.](https://assets.website-files.com/64149f79022d0c5fc8ce46e8/64149f79022d0cd45cce4719_Support%20Ninja%20%7C%20Full%20Logo.svg "owner")

#
