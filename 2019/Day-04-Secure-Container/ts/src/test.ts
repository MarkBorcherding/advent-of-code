#!/usr/bin/env npx mocha --require ts-node/register -r tsconfig-paths/register

import calculate from "./calculate";
import assert from "assert";
import { describe, it } from "mocha";

describe("Example Data", () => {
  it("has the right number", () => {
    assert.equal(1, calculate("171309-643603"));
  });
});
