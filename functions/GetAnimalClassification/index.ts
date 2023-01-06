import { AzureFunction, Context, HttpRequest } from "@azure/functions";
const imageToBase64 = require("image-to-base64");

const apiKey = process.env["API_KEY"];
const apiUrl = process.env["API_URL"];
const deploymentName = process.env["DEPLOYMENT_NAME"];

const httpTrigger: AzureFunction = async function (
  context: Context,
  req: HttpRequest
): Promise<void> {
  if (req.method !== "POST") {
    context.res = {
      status: 200,
      body: "Method not supported",
    };

    return;
  }

  if (!req.body.imageUrl) {
    context.res = {
      status: 400,
      body: "imageUrl is required",
    };

    return;
  }

  const imageBase64 = await imageToBase64(req.body.imageUrl);

  const requestBody = {
    input_data: {
      columns: ["image"],
      data: [
        [imageBase64], // base64-encoded image goes here
      ],
    },
  };

  const options = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${apiKey}`,
      "azureml-model-deployment": deploymentName,
    },
    body: JSON.stringify(requestBody),
  };

  const res = await fetch(apiUrl, options).then((response) => {
    if (!response.ok) {
      console.log(`The request failed with status code: ${response.status}`);
    }

    return response.json();
  });

  const response = {
    predictions: res?.[0]?.labels.map((label, index) => {
      return {
        animal: label,
        probability: res[0].probs[index],
      };
    }),
  };

  context.res = {
    body: {
      result: response,
    },
  };
};

export default httpTrigger;
