<template>
  <div class="create">
    <div class="container-fluid">
      <div class="row justify-content-md-center">
        <div class="form-group col-md-6">
          <input id="inputHash" v-model="noteHash" placeholder="Enter hash" class="form-control" required="required">
          <br>
          <textarea id="getNoteFormControlTextarea" placeholder="There will be your note" v-model="noteText" class="form-control" rows="6"></textarea>
        </div>
      </div>

      <div class="row justify-content-md-center">
        <button type="button" class="btn btn-primary" v-on:click="getNote">Watch</button>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: 'Get',
  data() {
    return {
      noteText: '',
      noteHash: ''
    }
  },
  methods: {
    getNote: async function () {
      if (this.noteHash !== '') {
        this.noteText = (await axios.get('https://localhost:35050/getNote?hash=' + this.noteHash)).data;
      }
    }
  }
}
</script>
